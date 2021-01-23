    public partial class ProgressForm : Form
    {
      private readonly CancellationTokenSource _cancellationTokenSource;
      public ProgressForm(CancellationTokenSource cancellationTokenSource, IProgress<string> progress)
      {
        InitializeComponent();
        _cancellationTokenSource = cancellationTokenSource;
        progress.ProgressChanged += ((o, i) => this.ProgressLabel.Text = i.ToString());
      }
      public static void ShowDialog(CancellationTokenSource cancellationTokenSource, IProgress<string> progress)
      {
        using (var progressForm = new ProgressForm(cancellationTokenSource, progress))
        {
            progressForm.ShowDialog();
        }
      }
      private void CancelXButton_Click(object sender, EventArgs e)
      {
        if (this._cancellationTokenSource != null)
          this._cancellationTokenSource.Cancel();
      }
    }
