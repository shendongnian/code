    public partial class _Default : System.Web.UI.Page 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    	// SQL Code here
    
    	// Datatable code here 
        // End of DataTable code
        // Beginning of IF blocks   
            If (DataTable.Rows.Count > 0) {
            If (your check != "checkbox") {
            this.PlaceHolder1.Controls.Add(new Button(){
                Text = "Added"}
                }
              }
         // More if statements here
           );
    
        }
    }
