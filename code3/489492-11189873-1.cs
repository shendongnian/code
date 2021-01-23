    using System;
    using umbraco.BusinessLogic;
    using Umbraco.Forms.Core;
    using Umbraco.Forms.Data.Storage;
    public class FormArchiveListener : ApplicationBase
    {
	    public FormArchiveListener()
	    {
            FormStorage.FormUpdated += new EventHandler<FormEventArgs>(FormStorage_FormUpdated);
	    }
        void FormStorage_FormUpdated(object sender, FormEventArgs e)
        {
            Form form = (Form)sender;
            if (form.Archived)
            {
                ...
            }
        }
    }
