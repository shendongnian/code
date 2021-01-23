		using System.Net;
		using System.Security.Cryptography.Xml;
		using System.Security.Cryptography.X509Certificates;
		namespace ConsoleApplication1
		{
			public class A
			{
				private string website = "https://www.chase.com/";
				private X509Certificate m_certificate;
				public X509Certificate Certificate
				{
					get
					{
						if (m_certificate == null)
						{
							HttpWebRequest request = (HttpWebRequest)WebRequest.Create(website);
							HttpWebResponse response = (HttpWebResponse) request.GetResponse();
							response.Close();
							X509Certificate cert = request.ServicePoint.Certificate;
							m_certificate = cert;
						}
						return m_certificate;
					}
				}
				public X509Certificate2 Certificate2
				{
					get
					{
						return new X509Certificate2(Certificate);
					}
				}
			}
			public class B
			{
				public KeyInfo publicKey { get; set; }
				public KeyInfo privateKey { get; set; }
			}
			class Program
			{
				private static void Main(string[] args)
				{
					A tempA = new A();
					B tempB = new B();
					tempB.privateKey = tempA.Certificate.GetPublicKey(); // fails
				}
			}
		}
