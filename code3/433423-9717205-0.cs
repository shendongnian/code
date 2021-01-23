    public class WadLogEntity
           : Microsoft.WindowsAzure.StorageClient.TableServiceEntity
        {
            public WadLogEntity()
            {
                PartitionKey = "a";
                RowKey = string.Format("{0:10}_{1}", DateTime.MaxValue.Ticks - DateTime.Now.Ticks, Guid.NewGuid());
            }
    
            public string Role { get; set; }
            public string RoleInstance { get; set; }
            public int Level { get; set; }
            public string Message { get; set; }
            public int Pid { get; set; }
            public int Tid { get; set; }
            public int EventId { get; set; }
            public DateTime EventDateTime
            {
                get
                {
                    return new DateTime(long.Parse(this.PartitionKey.Substring(1)));
                }
            }
        }
