	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Net;
	using System.IO;
	namespace ZUtilities.SSRS {
		public enum ReportFormats {
			Html = 1,
			MHtml,
			Pdf,
			Xlsx,
			Docx
		}
		public class ReportFormat {
			static ReportFormat() {
				Html = new ReportFormat { Code = ReportFormats.Html, Instruction = "HTML4.0" };
				MHtml = new ReportFormat { Code = ReportFormats.MHtml, Instruction = "MHTML" };
				Pdf = new ReportFormat { Code = ReportFormats.Pdf, Instruction = "PDF" };
				Xlsx = new ReportFormat { Code = ReportFormats.Xlsx, Instruction = "EXCELOPENXML" };
				Docx = new ReportFormat { Code = ReportFormats.Docx, Instruction = "WORDOPENXML" };
			}
			private ReportFormat() {
			}
			public ReportFormats Code { get; set; }
			public String Instruction { get; set; }
			public static ReportFormat Html { get; private set; }
			public static ReportFormat MHtml { get; private set; }
			public static ReportFormat Pdf { get; private set; }
			public static ReportFormat Xlsx { get; private set; }
			public static ReportFormat Docx { get; private set; }
			public static ReportFormat ByCode(ReportFormats code) {
				switch (code) {
					case ReportFormats.Html: return Html;
					case ReportFormats.MHtml: return Html; //<<======================
					case ReportFormats.Pdf: return Pdf;
					case ReportFormats.Xlsx: return Xlsx;
					case ReportFormats.Docx: return Docx;
					default : return null;
				}
			}
		}
		public class Report : IDisposable {
			private HttpWebRequest _httpWReq;
			private WebResponse _httpWResp;
			
			public Report() {
				_httpWReq = null;
				_httpWResp = null;
				Format = ReportFormats.Html;
				Params = new Dictionary<String, String>();
			}
			public Dictionary<String, String> Params { get; set; }
			public String ReportServerPath { get; set; }
			public String ReportPath { get; set; }
			public ReportFormats Format { get; set; }
			public NetworkCredential Credentials { get; set; }
			//public String PostData { get { return String.Format("rs:Command=Render&rs:Format={0}", ReportFormat.ByCode(Format).Instruction); } }
			public String PostData { get {
				StringBuilder sb = new StringBuilder(1024);
				sb.AppendFormat("rs:Command=Render&rs:Format={0}", ReportFormat.ByCode(Format).Instruction);
				if (Format == ReportFormats.Html) {
					sb.Append("&rc:Toolbar=false");
				}
				foreach (var kv in Params) {
					sb.AppendFormat("&{0}={1}", kv.Key, kv.Value);
				}
				return sb.ToString();
			} }
			public String ReportFullPath { get { return ReportServerPath + "?/" +  ReportPath; } }
			public Stream Render() {
				_httpWReq = (HttpWebRequest)HttpWebRequest.Create(ReportFullPath);
				_httpWReq.Method = "POST";
				if (Credentials != null)
					_httpWReq.Credentials = Credentials;
				byte[] byteArray = Encoding.UTF8.GetBytes(PostData);
				_httpWReq.ContentType = "application/x-www-form-urlencoded";
				_httpWReq.ContentLength = byteArray.Length;
				Stream dataStream = _httpWReq.GetRequestStream();
				dataStream.Write(byteArray, 0, byteArray.Length);
				dataStream.Close();
				if (_httpWResp != null )
				    _httpWResp.Close();
                                _httpWResp = _httpWReq.GetResponse();               
				return _httpWResp.GetResponseStream();
			}
			
			public void RenderTo(String fileName) {            
				Stream receiveStream = Render();
				Stream ds = File.Open(fileName, FileMode.Create);
				receiveStream.CopyTo(ds);
				ds.Close();
				receiveStream.Close();            
			}
			public void Dispose() {
				if (_httpWResp != null) {
					_httpWResp.Close();
					_httpWResp = null;
				}
				if (_httpWReq != null) {
					_httpWReq = null;
				}
			}
		}
	}
