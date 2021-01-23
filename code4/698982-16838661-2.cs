                StringBuilder sbrCSVData = new StringBuilder();
                int intStartIndex = 1;
                int intIndexCnt = 0;
                int intMaxRecords = 10000;
                AnalyticsService objAnaSrv = new AnalyticsService(objInit);
                string metrics = "ga:visitors,ga:visits,ga:visitBounceRate,ga:pageviews,ga:pageviewsPerVisit,ga:uniquePageviews,ga:avgTimeOnPage,ga:exits,ga:avgPageLoadTime,ga:goal1ConversionRate";
                DataResource.GaResource.GetRequest objRequest = objAnaSrv.Data.Ga.Get(strProfId, startDate,endDate, metrics);
                objRequest.Dimensions = "ga:visitCount,ga:browser,ga:browserVersion,ga:IsMobile,ga:screenResolution,ga:date,ga:hour";
                objRequest.MaxResults = 10000;
    
                while (true)
                {
                    objRequest.StartIndex = intStartIndex;
                    GaData objResponse = objRequest.Fetch();
                    objResponse.ItemsPerPage = intMaxRecords;
                   
                      if (objResponse.Rows != null)
                    {
                        intIndexCnt++;
                        for (int intRows = 0; intRows < objResponse.Rows.Count; intRows++)
                        {
                            IList<string> lstRow = objResponse.Rows[intRows];
                            for (int intCols = 0; intCols <= lstRow.Count - 1; intCols++)
                            {
                                strRowData += lstRow[intCols].ToString() + "|";
                            }
                            strRowData = strRowData.Remove(strRowData.Length - 1, 1);
                            sbrCSVData.Append(strRowData + "\r\n");
                            strRowData = "";
                        }
                        intStartIndex = intIndexCnt * intMaxRecords + 1;
                    }
                    else break;
                }
