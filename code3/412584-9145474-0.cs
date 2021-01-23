    public sealed class Helper {
    ///Gets or sets BaseController
    public BaseController { get; set; }
    #region "Constructors"
    /// <summary>
    /// Initialises a new instance of the <see cref="Helper" /> class.
    /// </summary>
    public Helper() : base() {
     
    }
    /// <summary>
    /// Initialises a new instance of the <see cref="Helper" /> class.
    /// </summary>
    public Helper(BaseController baseController) : this() {
       this.BaseController = baseController;
    }
    #endregion
    public void SendEmail(){
       // Here you can call your RenderPartialViewToString from the BaseController
     var m_RenderPartialViewToString = this.BaseController.RenderPartialViewToString( .......);
    }}
