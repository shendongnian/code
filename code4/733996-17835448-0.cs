    public class ChannelRowCell
    {
        public string Name { get; set; }
        public string Delay { get; set; }
        public string Trigger { get; set; }
        public string Restore { get; set; }
    }
    public class ChannelRow
    {
        public int Id { get; set; }
        public List<ChannelRowCell> Cells { get; set; }
    }
    public static class DigiChannelsExtensions
    {
        public static List<ChannelRow> GetRows(this List<DigiChannelsVM> digiChannelsVms)
        {
            var blocks = (from vm in digiChannelsVms
                          let ch = vm.ChannelCollectionItems.Select(item => new 
                          {
                              vm.Id,
                              Type = item.Types.EnumDataItems.FirstOrDefault(xx => xx.IsSet).Description,
                              Delay = item.Delay.Value.ToString(),
                              Trigger = item.Trigger.Value == 0 ? "+" : "-",
                              Restore = item.Restore.GetSelectedEnumItems().FirstOrDefault().Description == "Restore" ? "Y" : "N",
                          }).ToList()
                          select new { Id = vm.Id.Value, Channels = ch }).ToList();
            var channelRows = new List<ChannelRow>();
            //for (var i = 0; i < blocks[0].Channels.Count; i++)
            for (var i = 0; i < blocks[0].Channels.Count; i++)
            {
                var channelRow = new ChannelRow { Cells = new List<ChannelRowCell>(), Id = i+1 };
                foreach (var cc in blocks.Select(block => block.Channels[i]))
                {
                    channelRow.Cells.Add(new ChannelRowCell
                    {
                        Delay = cc.Delay,
                        Name = cc.Type,
                        Restore = cc.Restore,
                        Trigger = cc.Trigger,
                    });
                }
                channelRows.Add(channelRow);
            }
            return channelRows;
        }
    }
