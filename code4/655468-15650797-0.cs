    var inputString = "Config: EbizNewTestProject.dll PaymentSOAUrl for Paid: http://111.11.11.111/Payment.asp?" + Environment.NewLine;
                inputString += "Exception: <Response> <ReturnCode>4000</ReturnCode> <SuccessCode>NO</SuccessCode> <ReturnDesc>System Error</ReturnDesc> <ReturnURL>http://localhost/Default.aspx</ReturnURL> <CustomParameter /> </Response>: " + Environment.NewLine;
                inputString += "Config: EbizNewTestProject.dll PaymentSOAUrl for Paid: http://111.11.11.111/Payment.asp? " + Environment.NewLine;
                inputString += "Exception: <Response> <ReturnCode>4000</ReturnCode> <SuccessCode>NO</SuccessCode> <ReturnDesc>System Error</ReturnDesc> <ReturnURL>http://localhost/Default.aspx</ReturnURL> <CustomParameter /> </Response>: " + Environment.NewLine;
                inputString += "Config: PartnerServicesTestBase.dll PaymentSOAUrl for Paid: https://172.31.26.38/Payment.asp? " + Environment.NewLine;
                inputString += "Exception: <Response> <ReturnCode>5000</ReturnCode> <SuccessCode>NO</SuccessCode> <ReturnDesc>System Error</ReturnDesc> <ReturnURL>http://localhost/Default.aspx</ReturnURL> <CustomParameter /> </Response>: " + Environment.NewLine;
                inputString += "Config: PartnerServicesTestBase.dll PaymentSOAUrl for Paid: https://172.31.26.38/Payment.asp? " + Environment.NewLine;
                inputString += "Exception: <Response> <ReturnCode>5000</ReturnCode> <SuccessCode>NO</SuccessCode> <ReturnDesc>System Error</ReturnDesc> <ReturnURL>http://localhost/Default.aspx</ReturnURL> <CustomParameter /> </Response>: " + Environment.NewLine;
                inputString += "Config: EbizNewTestProject.dll PaymentSOAUrl for Paid: http://111.11.11.111/Payment.asp? " + Environment.NewLine;
                inputString += "Exception: <Response> <ReturnCode>4000</ReturnCode> <SuccessCode>NO</SuccessCode> <ReturnDesc>System Error</ReturnDesc> <ReturnURL>http://localhost/Default.aspx</ReturnURL> <CustomParameter /> </Response>: " + Environment.NewLine;
    
    
                TextReader reader = new StringReader(inputString);
                string line = null;
                StringBuilder sb = new StringBuilder();
                string firstLine = null;
               
    
                //append the first line
                sb.AppendLine(reader.ReadLine());
    
                //read the first exception line
                firstLine = reader.ReadLine();
                sb.AppendLine(firstLine);
    
    
    
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Exception:"))
                    {
    
                        if (line == firstLine)
                        {
                            sb.AppendLine("Exception:-- Do --");
                        }
    
                        if (line != firstLine)
                        {
                            sb.AppendLine(line);
                            firstLine = line;
    
                        }
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }
             
    
                Console.WriteLine(sb.ToString());
    
                Console.ReadKey();
