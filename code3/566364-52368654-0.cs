            var eTag = department.RowVersion.ToETagString();
           
            httpClient.DefaultRequestHeaders.Add(Microsoft.Net.Http.Headers.HeaderNames.IfMatch, $"\"{eTag}\"")
        
        
        public class DepartmentForHandleDto
        {
            public string Name { get; set; }
            public string GroupName { get; set; }
            public byte[] RowVersion { get; set; }
        }
        
        public static class ByteArrayExtensions
        {
            public static string ToETagString(this byte[] byteArray)
            {
                return Convert.ToBase64String(byteArray != null && byteArray.Length > 0 ? byteArray : new byte[8]);                    
            }
        }
