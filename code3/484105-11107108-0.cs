    appHost.ResponseFilters.Add((req, res, dto) =>
    {
        if (req.ResponseContentType == ContentType.Xml)
        {
            var sb = new StringBuilder();
            DataDto dataDto = (DataDto)dto;
            sb.AppendLine("<data>");
            sb.AppendFormat("<id>{0}</id>",dataDto.Id);
            //... etc
            res.ContentType = ContentType.Xml;
            using (var sw = new StreamWriter(res.OutputStream)) {
              sw.WriteLine(sb.ToString());
            }
            res.Close();
        }
    });
