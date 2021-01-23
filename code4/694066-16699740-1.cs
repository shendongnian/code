        protected void gvOutput_RowDataBound(object sender, GridViewRowEventArgs e)
        {
    
            try
            {
               
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                //get radio button value selected by user (default is all)
                if (rdAll.Checked)
                    search.SearchType = rdAll.Value;
                else if (rdBelowTrigger.Checked)
                    search.SearchType = rdBelowTrigger.Value;
                else if (rdAboveTrigger.Checked)
                    search.SearchType = rdAboveTrigger.Value;
                else if (rdBelowSafety.Checked)
                    search.SearchType = rdBelowSafety.Value;
                else if (rdBelowXWeeksWPO.Checked)
                    search.SearchType = rdBelowXWeeksWPO.Value
    
                  //Hide the Textbox
                   TextBox txtQtyOrder10 = (TextBox)e.Row.FindControl("txtQtyOrder10");
                   txtQtyOrder10.Visible = false;
    
                }
            }
            catch (Exception ex)
            {
                LoggingComponent.Instance.LogMessage(bo.Enums.LoggingType.Error, DateTime.Now, ex.Message, bo.Enums.Module.Order, "gvProductsAdded_RowDataBound", bo.Enums.ApplicationLevel.FrontEnd, "Error en los Productos a Despachar");
                DisplayMessage(GetGlobalResourceObject("Messages", "UnknowError").ToString(), bo.Enums.MessageType.Error);
            }
    
    
        }
