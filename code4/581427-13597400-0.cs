     var address = "#306, Los Angel,opp Line Tower,3rd cross\nAng Mo Kio Al-mera 520506\nDubai".Split(new[] { ',', '\n' });
            var array = Page.Request["Address"].ToString().Split(new[] { ',', '\n' });
            if (array.Count() != 0)
            {
                if (array[array.Count() - 1].ToString() != "") // Country
                    sCountry = array[array.Count() - 1].ToString();
                else
                    sCountry = "";
                var sTemp = array[array.Count() - 2].ToString().Split(new[] { ' ' });
                if (sTemp.Count() != 0)
                {
                    // PostalCode
                    if (sTemp[sTemp.Count() - 1].ToString() != "")
                    {
                        sPostalCode = sTemp[sTemp.Count() - 1].ToString();
                    }
                    else
                    {
                        sPostalCode = "";
                    }
                    //State Name
                    if (sTemp[sTemp.Count() - 2].ToString() != "")
                    {
                        sState = sTemp[sTemp.Count() - 2].ToString();
                    }
                    else
                    {
                        sState = "";
                    }
                }
                else
                {
                    sPostalCode = "";
                    sState = "";
                }
                if (array[array.Count() - 3].ToString() != "") // City
                    sCity = array[array.Count() - 3].ToString();
                else
                    sCity = "";
                for (int i = 0; i < (array.Count() - 3); i++)  // Street
                {
                    sStreet = sStreet + array[i].ToString();
                }
            }
