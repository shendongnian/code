    using System;
    using Extensibility;
    using EnvDTE;
    using EnvDTE80;
    using Microsoft.VisualStudio.CommandBars;
    using System.Resources;
    using System.Reflection;
    using System.Globalization;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    namespace ReplaceF1
    {
	    /// <summary>The object for implementing an Add-in.</summary>
	    /// <seealso class='IDTExtensibility2' />
	    public class Connect : IDTExtensibility2, IDTCommandTarget
	    {
		    /// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		    public Connect()
		    {
		    }
            MsdnExplorer.MainWindow Explorer = new MsdnExplorer.MainWindow();
		    /// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		    /// <param term='application'>Root object of the host application.</param>
		    /// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		    /// <param term='addInInst'>Object representing this Add-in.</param>
		    /// <seealso class='IDTExtensibility2' />
		    public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		    {
			    _applicationObject = (DTE2)application;
			    _addInInstance = (AddIn)addInInst;
			    if(connectMode == ext_ConnectMode.ext_cm_UISetup)
			    {
				    object []contextGUIDS = new object[] { };
				    Commands2 commands = (Commands2)_applicationObject.Commands;
				    string toolsMenuName;
				    try
				    {
					    // If you would like to move the command to a different menu, change the word "Help" to the 
					    //  English version of the menu. This code will take the culture, append on the name of the menu
					    //  then add the command to that menu. You can find a list of all the top-level menus in the file
					    //  CommandBar.resx.
					    ResourceManager resourceManager = new ResourceManager("ReplaceF1.CommandBar", Assembly.GetExecutingAssembly());
					    CultureInfo cultureInfo = new System.Globalization.CultureInfo(_applicationObject.LocaleID);
					    string resourceName = String.Concat(cultureInfo.TwoLetterISOLanguageName, "Help");
					    toolsMenuName = resourceManager.GetString(resourceName);
				    }
				    catch
				    {
					    //We tried to find a localized version of the word Tools, but one was not found.
					    //  Default to the en-US word, which may work for the current culture.
					    toolsMenuName = "Help";
				    }
				    //Place the command on the tools menu.
				    //Find the MenuBar command bar, which is the top-level command bar holding all the main menu items:
				    Microsoft.VisualStudio.CommandBars.CommandBar menuBarCommandBar = ((Microsoft.VisualStudio.CommandBars.CommandBars)_applicationObject.CommandBars)["MenuBar"];
				    //Find the Tools command bar on the MenuBar command bar:
				    CommandBarControl toolsControl = menuBarCommandBar.Controls[toolsMenuName];
				    CommandBarPopup toolsPopup = (CommandBarPopup)toolsControl;
				    //This try/catch block can be duplicated if you wish to add multiple commands to be handled by your Add-in,
				    //  just make sure you also update the QueryStatus/Exec method to include the new command names.
				    try
				    {
					    //Add a command to the Commands collection:
					    Command command = commands.AddNamedCommand2(_addInInstance, 
                            "ReplaceF1", 
                            "MSDN Advanced F1", 
                            "Brings up context-sensitive Help via the MSDN Add-in", 
                            true, 
                            59, 
                            ref contextGUIDS, 
                            (int)vsCommandStatus.vsCommandStatusSupported+(int)vsCommandStatus.vsCommandStatusEnabled, 
                            (int)vsCommandStyle.vsCommandStylePictAndText, 
                            vsCommandControlType.vsCommandControlTypeButton);
                        command.Bindings = new object[] { "Global::F1" };
				    }
				    catch(System.ArgumentException)
				    {
					    //If we are here, then the exception is probably because a command with that name
					    //  already exists. If so there is no need to recreate the command and we can 
                        //  safely ignore the exception.
				    }
			    }
		    }
		    /// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		    /// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		    /// <param term='custom'>Array of parameters that are host application specific.</param>
		    /// <seealso class='IDTExtensibility2' />
		    public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		    {
		    }
		    /// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		    /// <param term='custom'>Array of parameters that are host application specific.</param>
		    /// <seealso class='IDTExtensibility2' />		
		    public void OnAddInsUpdate(ref Array custom)
		    {
		    }
		    /// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		    /// <param term='custom'>Array of parameters that are host application specific.</param>
		    /// <seealso class='IDTExtensibility2' />
		    public void OnStartupComplete(ref Array custom)
		    {
		    }
		    /// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		    /// <param term='custom'>Array of parameters that are host application specific.</param>
		    /// <seealso class='IDTExtensibility2' />
		    public void OnBeginShutdown(ref Array custom)
		    {
		    }
		
		    /// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
		    /// <param term='commandName'>The name of the command to determine state for.</param>
		    /// <param term='neededText'>Text that is needed for the command.</param>
		    /// <param term='status'>The state of the command in the user interface.</param>
		    /// <param term='commandText'>Text requested by the neededText parameter.</param>
		    /// <seealso class='Exec' />
		    public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		    {
			    if(neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
			    {
				    if(commandName == "ReplaceF1.Connect.ReplaceF1")
				    {
					    status = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported|vsCommandStatus.vsCommandStatusEnabled;
					    return;
				    }
                }
		    }
		    /// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
		    /// <param term='commandName'>The name of the command to execute.</param>
		    /// <param term='executeOption'>Describes how the command should be run.</param>
		    /// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
		    /// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
		    /// <param term='handled'>Informs the caller if the command was handled or not.</param>
		    /// <seealso class='Exec' />
		    public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		    {
			    if(executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
			    {
                    if (commandName == "ReplaceF1.Connect.ReplaceF1")
				    {
                        // Get a reference to Solution Explorer.
                        Window activeWindow = _applicationObject.ActiveWindow;
                        ContextAttributes contextAttributes = activeWindow.DTE.ContextAttributes;
                        contextAttributes.Refresh();
                        List<string> attributes = new List<string>();
                        try
                        {
                            ContextAttributes highPri = contextAttributes == null ? null : contextAttributes.HighPriorityAttributes;
                            highPri.Refresh();
                            if (highPri != null)
                            {
                                foreach (ContextAttribute CA in highPri)
                                {
                                    List<string> values = new List<string>();
                                    foreach (string value in (ICollection)CA.Values)
                                    {
                                        values.Add(value);
                                    }
                                    string attribute = CA.Name + "=" + String.Join(";", values.ToArray());
                                    attributes.Add(CA.Name + "=");
                                }
                            }
                        }
                        catch (System.Runtime.InteropServices.COMException e)
                        {
                            // ignore this exception-- means there's no High Pri values here
                            string x = e.Message;
                        }
                        catch (System.Reflection.TargetInvocationException e)
                        {
                            // ignore this exception-- means there's no High Pri values here
                            string x = e.Message;
                        }
                        catch (System.Exception e)
                        {
                            System.Windows.Forms.MessageBox.Show(e.Message);
                            // ignore this exception-- means there's no High Pri values here
                            string x = e.Message;
                        }
                        // fetch context attributes that are not high-priority
                        foreach (ContextAttribute CA in contextAttributes)
                        {
                            List<string> values = new List<string>();
                            foreach (string value in (ICollection)CA.Values)
                            {
                                values.Add (value);
                            }
                            string attribute = CA.Name + "=" + String.Join(";", values.ToArray());
                            attributes.Add (attribute);
                        }
                        // Replace this call with whatever you want to do with the help context info 
                        HelpHandler.HandleF1 (attributes);
				    }
			    }
		    }
		    private DTE2 _applicationObject;
		    private AddIn _addInInstance;
	    }
    }
