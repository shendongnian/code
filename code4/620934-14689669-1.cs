        public void Run(ClientPipelineArgs args)
        {
            try
            {
                if (!args.IsPostBack)
                {
                    Context.ClientPage.ClientResponse.ShowModalDialog(url.ToString(), true);
                    args.WaitForPostBack();
                }
                else if (args.HasResult)
                {
                    // Small job confirmation. User decide 'no'
                    if (args.Result == "no")
                    {
                        return;
                    }
                    if(args.Result == "result")
                    {
                      SheerResponse.Confirm("message");
                      args.WaitForPostBack();
                    }
                }
            }
            catch (EndpointNotFoundException ex)
            {
		//something	
            }
        }
