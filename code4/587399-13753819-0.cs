      /// <summary>
        /// Gridview Row Data Bound 
        /// </summary>
        protected void grdvOffers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Converts the UTC date to PST timezone
            if (e.Row.RowType == DataControlRowType.DataRow)
            {  
                Offer offer = ((Offer)e.Row.DataItem);
                offer.Created = TimeZoneInfo.ConvertTimeFromUtc(offer.Created, CFrmFunctions.GetPresetTimeZone());
                e.Row.DataItem = offer;
                e.Row.DataBind();
            }
        }
