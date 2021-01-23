                int hitCount;
                Item root = MasterDatabase.GetItem(Constants.ARI_BUCKET_LOCATION_ID);
                using (new SecurityDisabler())
                {
                    Sitecore.Context.SetActiveSite("website");
                    var items = root.Search(out hitCount,
                                        text: "*",
                                        indexName: "itembuckets_buckets",
                                        location: root.ID.ToString(),
                                        language: "en",
                                        startDate: "01/01/2013",
                                        endDate: "12/31/2013",
                                        numberOfItemsToReturn: 100,
                                        pageNumber: 1,
                                        templates: "{3B0476F4-C3C4-43DD-8490-2B3FF67C368B}");
                }
