    var xmlStr = @"<Root>
        <TEST>
            <A>10</A>
            <B>20</B>
        </TEST>
    </Root>";
    var table = new DataTable("TEST");
    table.Columns.Add("A", typeof(string));
    table.Columns.Add("B", typeof(string));
    table.ReadXml(new StringReader(xmlStr));
