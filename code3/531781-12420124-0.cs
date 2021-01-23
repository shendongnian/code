    using (SPLimitedWebPartManager mgrPageManager = pageOrganisation.GetLimitedWebPartManager(PersonalizationScope.Shared))
                            {
                                SPList organisations = oHomeWeb.GetSafeListByName(SponsoringCommon.Constants.LISTNAMES_ORGANISATIONS2);
                                XsltListViewWebPart lvwpOrganisation = mgrPageManager.WebParts[idWebPartRootOrganisation] as XsltListViewWebPart;
                                Functions.SetToolbarType(lvwpOrganisation, "Freeform");
    
                                mgrPageManager.SaveChanges(lvwpOrganisation);                          
                            }
    
    
     public static void SetToolbarType(XsltListViewWebPart lvwp, string viewType)
            {
                try
                {
                    MethodInfo ensureViewMethod = lvwp.GetType().GetMethod("EnsureView", BindingFlags.Instance | BindingFlags.NonPublic);
                    object[] ensureViewParams = { };
                    ensureViewMethod.Invoke(lvwp, ensureViewParams);
                    FieldInfo viewFieldInfo = lvwp.GetType().GetField("view", BindingFlags.NonPublic | BindingFlags.Instance);
                    SPView view = viewFieldInfo.GetValue(lvwp) as SPView;
                    Type[] toolbarMethodParamTypes = { Type.GetType("System.String") };
                    MethodInfo setToolbarTypeMethod = view.GetType().GetMethod("SetToolbarType", BindingFlags.Instance | BindingFlags.NonPublic, null, toolbarMethodParamTypes, null);
                    object[] setToolbarParam = { viewType }; //set the type here
                    setToolbarTypeMethod.Invoke(view, setToolbarParam);
                    view.Update();
                }
                catch { }
            }
