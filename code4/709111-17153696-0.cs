    private Binary _latestRowVersion = new Binary(new byte[] { 0 });
    private void Read()
    {
        using (var ctx = new DataContext())
        {
            var all =
                (from c in ctx.Categories
                 where c.RowVersion.Compare(_latestRowVersion) > 0
                 select c).ToList();
            if (all.Any())
            {
                _latestRowVersion =
                    all.OrderByDescending(
                        p => BitConverter.ToInt64(p.RowVersion.ToArray(), 0))
                    .First()
                    .RowVersion;
            }
        }
    }
    public static class BinaryComparer
    {
        public static int Compare(this Binary item1, Binary item2)
        {
            throw new NotImplementedException();
        }
    }
