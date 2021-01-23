		private void TabToOkayBtn(object sender, KeyEventArgs args)
		{
			if (args.Key == Key.Tab)
			{
				args.Handled = true;
				Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() => // input priority is always needed when changing focus
					_editor.TextArea.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next))));
			}
		}
