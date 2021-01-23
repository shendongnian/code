    public interface IFormResult<T>
    {
    	T Result { get; set; }
    }
    
    public class ModalForm1 : Form, IFormResult<string>
    {
    	public ModalForm1()
    	{
    		InitializeComponent();
    
    		this.Result = "My result";
    	}
    
    	public string Result { get; set; }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
    	string res = ShowModalForm<ModalForm1, string>();
    }
    
    private static T2 ShowModalForm<T1, T2>()
    	where T1 : Form, IFormResult<T2>, new()
    {
    	using (T1 form = new T1())
    	{
    		form.ShowDialog();
    
    		return form.Result;
    	}
    }
