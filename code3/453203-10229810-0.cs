    void R1_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
    
              // This event is raised for the header, the footer, separators, and items.
    
              // Execute the following logic for Items and Alternating Items.
              if (e.Item.ItemType == ListItemType.Item 
                      || e.Item.ItemType == ListItemType.AlternatingItem) 
                 {
    
                    var imgTopFourImg2 = e.Item.FindControl("imgTopFourImg2") as Image;
                    if (imgTopFourImg2 != null)
                        imgTopFourImg2.Attributes["onload"] = "onLoadFunction(this)";
                 }
              }
           }  
