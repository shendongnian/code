    string chartUrl = chart.GetUrl();
    byte[] chartBytes = null;
    WebClient client = new WebClient();
    chartBytes = client.DownloadData(chartUrl);
    using (var memStream = new MemoryStream())
    {
        memStream.Write(chartBytes, 0, chartBytes.Length);
    }
    File.WriteAllBytes("C:\temp\myChart.png", chartBytes);
