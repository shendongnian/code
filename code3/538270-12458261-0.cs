    Please try this ....           
     protected void Button1_Click(object sender, EventArgs e)
                {
                  using (CMSEntities cmsmodel = new CMSEntities())
                  {
                    if (GridView1.Rows.Count > 0)
                    {
                      foreach (GridViewRow row in GridView1.Rows)
                      {
                        Order order = new Order();
                
                        TextBox box1 = (TextBox)row.FindControl("itemTextBox");
                        TextBox box2 = (TextBox)row.FindControl("priceTextBox");
                        TextBox box3 = (TextBox)row.FindControl("txtQuantity");
                        CheckBox chkBx = (CheckBox)row.FindControl("ChkAddToOrder");
                
                        if (chkBx.Checked)
                        {
                          order.items = (box1.Text);
                          order.price = Convert.ToInt32(box2.Text);
                          order.quantity = Convert.ToInt32(box3.Text);
                          order.dateoforder = Convert.ToDateTime(DateTime.Now.ToString());
                
                         
                          String name = (String)Session["UserDetails"];
                
                          var types2 = (from p in cmsmodel.Logins
                                        //join w in cmsmodel.Orders on p.UserName equals name
                                        where p.UserName == name
                                        select p.ID).FirstOrDefault();
                
                          order.empid = types2;
                          //string result="NotFullfill";
                          //var type3 = (from p in cmsmodel.Status
                          //             where p.result== result
                          //             select p.statusid);
                
                          order.statusid = 2;
                
                          int a = Convert.ToInt32(box2.Text);
                          int b = Convert.ToInt32(box3.Text);
                          int totalprice = a * b;
                          order.totalprice = totalprice;
                 var types = (from p in cmsmodel.Items
                                       //join w in cmsmodel.Orders on p.items equals order.items
                                       where p.items == order.items
                                       select p.itemid).ToList();
            foreach(var x in types)
            {
             order.itemid = Convert.ToInt32(x);
            cmsmodel.Orders.AddObject(order);
           }
                          cmsmodel.SaveChanges();       
                        }              
                
                        Label1.Text = "inserted sucessfully";
                        Label1.Visible = true;
                      }
                    }
                  }
                }
