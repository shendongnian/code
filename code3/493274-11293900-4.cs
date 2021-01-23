    button3.Click += (_, __) => SubmitForm();
    
    [RebindForm]
    private void SubmitForm(object sender, EventArgs e)
    {
        //do submission stuff
    }
    
    [Serializable]
    public class RebindFormAttribute : OnMethodBoundaryAspect
    {
        public override void OnSuccess( MethodExecutionArgs args )
        {
            MyForm form = args.InstanceTarget as MyForm; //I actually forgot the "InstanceTarget" syntax off the top of my head, but something like that is there
            if (form != null)
            {
                form.Rebind();
            }
        }
    }
