    [MessageContract(WrapperNamespace = "urn:BillSAFE", IsWrapped = true)]
    public abstract class Response
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        [MessageBodyMember(Name = "ack", Namespace = "")]
        public Ack Ack { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MessageBodyMember(Name = "errorList", Namespace = "")]
        public ICollection<Error> ErrorList { get; set; }
        #endregion
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        protected Response()
        {
            this.Ack = V209.Ack.Error;
            this.ErrorList = new List<Error>();
        }
        #endregion
    }
