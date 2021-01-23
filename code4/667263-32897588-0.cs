        private static void RenameFolder(SPHttpClient client, string webUrl,string folderUrl,string folderName)
        {
            var folderItemUrl = webUrl + "/_api/web/GetFolderByServerRelativeUrl('" + folderUrl + "')/ListItemAllFields";
            var data = client.ExecuteJson(folderItemUrl);
            var itemPayload = new {
                __metadata = new { type = data["d"]["__metadata"]["type"] },
                Title = folderName,
                FileLeafRef = folderName,
               
            };
            var  itemUrl = data["d"]["__metadata"]["uri"];
            var headers = new Dictionary<string, string>();
            headers["IF-MATCH"] = "*";
            headers["X-HTTP-Method"] = "MERGE";
            client.ExecuteJson((string)itemUrl, HttpMethod.Post, headers, itemPayload);
        }
