    private static Order CreateNewOrder(Order order, IList<OfferInfo> offerList, bool updateUser = true)
    {
        try
        {
            Guid? senderUserId = null;
            /// Process user first so that, the user details are stored even if there is any error in other areas
            /// 
            if (updateUser)
            {
                VerifyUserDetails(order.User);
                /// Create/update sending user.
                /// 
                senderUserId = BLUser.UpdateUser(order.User);
                order.User = null;
                Logger.WriteLog("Sender user added/updated successfully. UserID:" + senderUserId.ToString());
            }
            else
                senderUserId = order.UserId;
            /// Add company details before processing the order, so that the company details are stored if there is any error in other areas.
            /// 
            if (order.Company != null)
                order.CompanyId = BLCompany.UpdateCompany(order.Company).Id;
            /// Verify and process order
            /// 
            VerifyOrderDetails(order, offerList);
            using (IntreatEntities intreat = new IntreatEntities())
            {
                /// Find total amount for the order
                double orderAmt = 0;
                double tableOrderAmt = 0;
                order.Amount = 0;
                foreach (OfferInfo offer in offerList)
                {
                    orderAmt = (double)((from po in intreat.PartnerOffers
                                                  where po.Id == offer.OfferId
                                                  select po.Price * offer.Quantity).ToList()).Sum();
                    order.Amount += orderAmt;
                    //If isPos, consider for tip calculation
                    if (offer.IsPos)
                        tableOrderAmt += orderAmt;
                }
                //check if tip amount has to be calculated, by checking for the tableorderAmt
                if ((tableOrderAmt > 0) && (order.TipPercentage != null) && (order.TipPercentage.Value) > 0)
                {
                    double tipAmt = (tableOrderAmt * (order.TipPercentage.Value * .01));
                    order.TipAmount = Math.Round(tipAmt);
                    order.Amount = (double)(order.Amount + order.TipAmount);
                }
                order.CreatedDate = DateTime.Now;
                order.UserId = (Guid)senderUserId;
                Logger.WriteLog(string.Format(CultureInfo.InvariantCulture, "order.TableNumber:{0}", order.TableNumber == null ? "(empty)" : order.TableNumber.ToString()));
                /// Create and save order in db
                /// 
                intreat.Orders.AddObject(order);
                intreat.SaveChanges();
                order.Vouchers.Load();
                Logger.WriteLog("Order added successfully. OrderId:" + order.Id.ToString(CultureInfo.InvariantCulture));
            }
            return order;
        }
        catch (Exception ex)
        {
            Logger.WriteLog(ex);
            throw;
        }
    }
