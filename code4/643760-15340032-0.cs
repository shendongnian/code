    // Native (unmanaged)
    public enum CTMBeginTransactionError
    {
        CTM_BEGIN_TRX_SUCCESS = 0,
        CTM_BEGIN_TRX_ERROR_ALREADY_IN_PROGRESS,
        CTM_BEGIN_TRX_ERROR_NOT_CONNECTED
    };
    // Native (unmanaged)
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    internal struct CTMBeginTransactionResult
    {
        public IntPtr szTransactionID;
        public CTMBeginTransactionError error;
    };
    // Managed wrapper around native struct
    public class BeginTransactionResult
    {
        public string TransactionID;
        public CTMBeginTransactionError Error;
        internal BeginTransactionResult(CTMBeginTransactionResult nativeStruct)
        {
            // Manually marshal the string
            if (nativeStruct.szTransactionID == IntPtr.Zero) this.TransactionID = "";
            else this.TransactionID = Marshal.PtrToStringAnsi(nativeStruct.szTransactionID);
            this.Error = nativeStruct.error;
        }
    }
    [DllImport("libctmclient-0.dll")]
    internal static extern CTMBeginTransactionResult ctm_begin_customer_transaction(string ptr);
    public static BeginTransactionResult BeginCustomerTransaction(string transactionId)
    {
        CTMBeginTransactionResult nativeResult = Transactions.ctm_begin_customer_transaction(transactionId);
        return new BeginTransactionResult(nativeResult);
    }
