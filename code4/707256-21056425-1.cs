            /// <summary>
            /// Downloads the file from a SharePoint site
            /// </summary>
            /// <param name="url">Site Url</param>
            /// <param name="creds">Credentials</param>
            /// <param name="listTitle">List Title</param>
            /// <param name="listItemId">List Item Id</param>
            /// <param name="filePath">Download path</param>
            /// <returns></returns>
            private static void DownloadFile(string url, ICredentials creds, string listTitle, int listItemId,string filePath)
            {
                using (var clientContext = new ClientContext(url))
                {
                    clientContext.Credentials = creds;
    
                    var list = clientContext.Web.Lists.GetByTitle(listTitle);
                    var listItem = list.GetItemById(listItemId);
                    clientContext.Load(list);
                    clientContext.Load(listItem, i => i.File);
                    clientContext.ExecuteQuery();
                   
                    var fileRef = listItem.File.ServerRelativeUrl;
                    var fileInfo = Microsoft.SharePoint.Client.File.OpenBinaryDirect(clientContext, fileRef);
                    var fileName = Path.Combine(filePath,(string)listItem.File.Name);
                    using (var fileStream = System.IO.File.Create(fileName))
                    {
                       
                        fileInfo.Stream.CopyTo(fileStream);
                    }
                }
            }
