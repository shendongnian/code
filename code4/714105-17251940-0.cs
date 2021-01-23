    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
			handled = false;
			if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
			{
				if(commandName == "CurlyBraces.Connect.CurlyBraces")
				{
                    if (_applicationObject.ActiveDocument != null)
                    {
                        TextSelection objSel = (EnvDTE.TextSelection)(_applicationObject.ActiveDocument.Selection);
                        objSel.NewLine();
                        objSel.Insert("{"); objSel.Indent();
                        objSel.NewLine();
                        objSel.NewLine();
                        objSel.Insert("}"); objSel.Indent();
                        objSel.LineUp();
                        objSel.Indent();
                        objSel.SmartFormat();
                        objSel.LineUp();
                    }
				}
			}
		}
