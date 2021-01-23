    var o = dgvLines.CurrentRow.DataBoundItem as Order;
    var r = _rs.Lines
      .Where(y => y.InvoiceNo == o.InvoiceNo)
      .Select(x => new
        {
          ReturnNo = x.Return.ReturnNo,
          Part = x.Part,
          TagNames = x.Tags.Select( t => t.Name ),
        }
      )
      .ToList() // this runs the SQL on the database
      .Select( x => new
        {
          ReturnNo = x.ReturnNo,
          Part = x.Part,
          Tags = String.Join( ", ", x.TagNames ),
        }
      )
      .ToList();
      dgvExistingParts.DataSource = r;
