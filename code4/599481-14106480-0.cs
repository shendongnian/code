		using System.Security.Cryptography.Xml;
		using System.Security.Cryptography.X509Certificates;
		namespace ConsoleApplication1
		{
			public class A
			{
				public X509Certificate certificate;
			}
			 public class B
			{
				public KeyInfo publicKey { get; set; }
				public KeyInfo privateKey { get; set; }
			}
			class Program
			{
				static void Main(string[] args)
				{
					A tempA = new A();
					B tempB = new B();
					
					tempB.privateKey = tempA.certificate.GetPublicKey(); // fails
				}
			}
		}
