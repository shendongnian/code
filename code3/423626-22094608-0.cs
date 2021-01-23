    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json.Linq;
    namespace Management
    {
    	class DeliveryMapInfo
	    {
		string origin = @""; //Write the address of the origin here
		public DeliveryMapInfo() { }
		public int getDistanceTo(string destination)
		{
			System.Threading.Thread.Sleep(1000);
			int distance = -1;
			string url = "http://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&sensor=false";
			string requesturl = url;string content = fileGetJSON(requesturl);
			JObject _Jobj = JObject.Parse(content);
			try
			{
				distance = (int)_Jobj.SelectToken("routes[0].legs[0].distance.value");
				return distance / 1000;// Distance in KMS
			}
			catch
			{
				return distance / 1000;
			}
		}
		protected string fileGetJSON(string fileName)
		{
			string _sData = string.Empty;
			string me = string.Empty;
			try
			{
				if (fileName.ToLower().IndexOf("http:") > -1)
				{
					System.Net.WebClient wc = new System.Net.WebClient();
					byte[] response = wc.DownloadData(fileName);
					_sData = System.Text.Encoding.ASCII.GetString(response);
				}
				else
				{
					System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
					_sData = sr.ReadToEnd();
					sr.Close();
				}
			}
			catch { _sData = "unable to connect to server "; }
			return _sData;
		}
	}
}
