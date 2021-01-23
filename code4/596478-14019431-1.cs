	public partial class MainForm : Form
	{
		CheckAnswers checkanswers;
		...
		public MainForm()
		{
			checkanswers = new CheckAnswers(this);
			...
		}
	}
	public class CheckAnswers // Not sure why you inherit MainForm here, but it's not a good idea, as someone already stated
	{
		MainForm mainform;
		
		public CheckAnswers (MainForm main)
		{
			mainform = main;
		}
		...
	}
