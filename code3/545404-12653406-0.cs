    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace TurkTest {
    	class Program {
    
    		static void Main(string[] args) {
    			const string SERVICE_NAME = "AWSMechanicalTurkRequester";  // requester service for MTurk
    			const string TIMESTAMP_FORMAT = "yyyy-MM-ddTHH:mm:ss.fffZ";
    
    			// Modify these with your values.
    			const string operation = "GetAccountBalance";
    			const string accessKey = "<Your access key>";
    			const string secretAccessKey = "<Your secret access key>";
    
    			// Millisecond values in the timestamp string can result in intermittent BadClaimsSupplied errors.
    			// Get the current UTC time and use that to create a new time with milliseconds set to zero to avoid this case.
    			DateTime now = DateTime.UtcNow;
    			now = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, 0, DateTimeKind.Utc);
    			string timeStamp = now.ToString(TIMESTAMP_FORMAT, CultureInfo.InvariantCulture);
    
    			// Create the hash-based messaged authentication algorithm (SHA1) using our secret access key as the key.
    			var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secretAccessKey));
    
    			// Combine the service name, operation and timestamp and then hash them to produce the signature.
    			var dataBytes = Encoding.UTF8.GetBytes(SERVICE_NAME + operation + timeStamp);
    			string signature = Convert.ToBase64String(hmac.ComputeHash(dataBytes));
    
    			// Build the URL to send to Amazon
    			string url =
    				@"https://mechanicalturk.amazonaws.com/?Service=AWSMechanicalTurkRequester&AWSAccessKeyId={0}&Version=2012-03-25&Operation={1}&Signature={2}&Timestamp={3}";
    			url = string.Format(url, accessKey, operation, signature, timeStamp);
    
    			// Send a request and write the response to the console.
    			using (WebClient client = new WebClient()) {
    				using (StreamReader reader = new StreamReader(client.OpenRead(url))) {
    					Console.WriteLine(reader.ReadToEnd());
    				}
    			}
    
    			Console.Read();
    		}
    	}
    }
