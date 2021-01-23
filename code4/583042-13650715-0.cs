    public interface IBaseView
    {
        void Show();
        C Get<C>(string controlName) where C : Control; //Needed to later wire the events
    }
    public interface IView : IBaseView
    {
        TextBox ClientId { get; set; } //Need to expose this
        Button SaveClient { get; set; }
        ListBox MyLittleList { get; set; }
    }
    public partial class View : Form, IView
    {
        public TextBox ClientId //since I'm exposing it, my "concrete view" the controls are camelCased
        {
            get { return this.clientId; }
            set { this.clientId = value; }
        }
        public Button SaveClient
        {
            get { return this.saveClient; }
            set { this.saveClient = value; }
        }
        public ListBox MyLittleList
        {
            get { return this.myLittleList; }
            set { this.myLittleList = value; }
        }
        //The view must also return the control to be wired.
        public C Get<C>(string ControlName) where C : Control
        {
            var controlName = ControlName.ToLower();
            var underlyingControlName = controlName[0] + ControlName.Substring(1);
            var underlyingControl = this.Controls.Find(underlyingControlName, true).FirstOrDefault();
            //It is strange because is turning PascalCase to camelCase. Could've used _Control for the controls on the concrete view instead
            return underlyingControl as C;
        }
