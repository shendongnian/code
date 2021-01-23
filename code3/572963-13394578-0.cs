		public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
			handled = false;
			if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
			{
                handled = true;
                if (commandName == "TestAddMethod.Connect.TestAddMethod")
                {
                    Document activeDoc = _applicationObject.ActiveDocument;
                    if (activeDoc == null)
                        return;
                    ProjectItem prjItem = activeDoc.ProjectItem;
                    if (prjItem == null)
                        return;
                    FileCodeModel fcm = prjItem.FileCodeModel;
                    if (fcm == null)
                        return;
                    CodeElements ces = fcm.CodeElements;
                    // look for the namespace in the active document
                    CodeNamespace cns = null;
                    foreach (CodeElement ce in ces)
                    {
                        if (ce.Kind == vsCMElement.vsCMElementNamespace)
                        {
                            cns = ce as CodeNamespace;
                            break;
                        }
                    }
                    if (cns == null)
                        return;
                    ces = cns.Members;
                    if (ces == null)
                        return;
                    // look for the first class
                    CodeClass cls = null;
                    foreach (CodeElement ce in ces)
                    {
                        if (ce.Kind == vsCMElement.vsCMElementClass)
                        {
                            cls = ce as CodeClass;
                            break;
                        }
                    }
                    if (cls == null)
                        return;
                    CodeFunction cf = cls.AddFunction("TestMethod1", vsCMFunction.vsCMFunctionFunction, vsCMTypeRef.vsCMTypeRefVoid, -1, vsCMAccess.vsCMAccessPrivate);
                    cf.AddAttribute("TestMethod", "true");
                    TextPoint tp = cf.GetStartPoint(vsCMPart.vsCMPartBody);
                    EditPoint ep = tp.CreateEditPoint();
                    ep.Indent();
                    ep.Indent();
                    ep.Indent();
                    ep.Insert("string test = Helper.CodeExample();");
                }
			}
		}
