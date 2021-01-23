    var sb = new StringBuilder();
    foreach(var item in myCollection) {
      sb.AppendFormat("{0}={1}&", item.Name, HttpUtility.UrlEncode(item.Value.ToString()));
    }
    sb.Remove(sb.Length - 1, 1); // remove the last '&'
