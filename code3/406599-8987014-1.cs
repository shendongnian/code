    NVPCodec nvpCodec = new NVPCodec();
    string returnMessage;
    
    bool success = PayPal.CommitPayment(someTotal, token, payerId, out nvpCodec, out returnMessage);
//----------------------------------------------------------------------------//
    public static bool CommitPayment(decimal finalPaymentAmount, string token, string payerId, out NVPCodec nvpCodec, out string returnMessage)
            {
                nvpCodec = new NVPCodec();
                returnMessage = "";
                
                bool success = new NVPAPICaller().ConfirmPayment(finalPaymentAmount.ToString(), token, payerId, ref nvpCodec, ref returnMessage);
    
                return success;
            }
