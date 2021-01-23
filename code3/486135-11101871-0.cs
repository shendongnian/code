    public List<EcoBonusRequest> GetAllRequestsWaitForPayment()
                {
                    var query = _context.EcoBonusRequests.Where(p => p.CurrentStatus == RequestStatus.WaitingForPayment).Include("Dealer").Include("Vehicle");
                    var dealerExists = query.All(m => m.Dealer != null);
                    return query.ToList();
                }
