    #if DEBUG
            /// <summary>
            /// Code which runs when the data context is created; called from the constructor
            /// </summary>
            /// <remarks>Adds console and/or ASP.NET trace logger in DEBUG builds only</remarks>
            partial void OnCreated()
            {
                this.DebugBuildLogging();
            }
    #endif
