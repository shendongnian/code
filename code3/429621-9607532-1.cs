		using System.Threading;
		// Threading.
		private BackgroundWorker bgWorker;
		AutoResetEvent areProgressChanged = new AutoResetEvent(false);
		private void SendYourMessage()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			try
			{
				MySqlDataAdapter adapter = new MySqlDataAdapter();
				MySqlCommand cmd = new MySqlCommand(getEmail, connect.connection);
				cmd.Parameters.AddWithValue("@section", sectionSelect.SelectedValue);
				adapter.SelectCommand = cmd;
				// Show your progress.
				(bgWorker as BackgroundWorker).ReportProgress(progressBarValue, "Half Way through...");
				DataTable mailingList = new DataTable();
				adapter.Fill(mailingList);
				foreach (DataRow row in mailingList.Rows)
				{
					string rows = string.Format("{0}", row.ItemArray[0]);
					message.To.Add(rows);
				}
				SmtpClient client = new SmtpClient();
				client.Credentials = new NetworkCredential(email, password.Password);
				client.Host = "smtp.gmail.com";
				client.Port = 587;
				client.EnableSsl = true;
				client.Send(message);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				stopwatch.Stop();
				TimeSpan timeTaken = stopwatch.Elapsed;
				MessageBox.Show(String.Format("Your message has been sent. That took {0}s", timeTaken.Seconds));
			} 
		}
		private void SendMyMessage_Click(object sender, EventArgs e)
		{
			// Start job on new thread.
			bgWorker = new BackgroundWorker { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
			bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
			bgWorker.ProgressChanged += new ProgressChangedEventHandler(bgWorker_ProgressChanged);
			bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
			bgWorker.RunWorkerAsync();
		}
		void bgWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker thisWorker = sender as BackgroundWorker;
			SendYourMessage();
		}
		void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Change progress bar (and form label).
			this.progressBar.Value = e.ProgressPercentage;
			this.label.Text = e.UserState;
			// Tell the worker that the UIThread has been updated.
			this.areProgressChanged.Set();
			return;
		}
		// Once the work is complete do something.
		void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// Handle.
			if (e.Cancelled || bgWorker.CancellationPending)
				MessageBox.Show("Message cancelled at users request!");
			else if (e.Error != null)
				MessageBox.Show(String.Format("Error: {0}.", e.Error.ToString()));
			return;
		}
		// To cancel the job.
		private void cancelAsyncButton_Click(System.Object sender, System.EventArgs e)
        {   
            if (bgWorker.WorkerSupportsCancellation)
                bgWorker.CancelAsync();
        }
