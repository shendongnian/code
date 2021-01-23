    #if BricsCad
                    CADAPI.ApplicationServices.Application.SystemVariableChanged += new CADAPI.ApplicationServices.SystemVariableChangedEventHandler(Application_SystemVariableChanged);
    #else
                    CADDB.LayoutManager.Current.LayoutSwitched += new CADDB.LayoutEventHandler(Current_LayoutSwitched);
    #endif
