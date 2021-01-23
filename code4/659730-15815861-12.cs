    <configuration>
        <connectionStrings>
            <add name="OdbcSessionServices" connectionString="DSN=SessionState;" />
        </connectionStrings>
        <system.web>
            <sessionState 
                    cookieless="true"
                    regenerateExpiredSessionId="true"
                    mode="Custom"
                    customProvider="OdbcSessionProvider">
                <providers>
                    <add name="OdbcSessionProvider"
                            type="Samples.AspNet.Session.OdbcSessionStateStore"
                            connectionStringName="OdbcSessionServices"
                            writeExceptionsToEventLog="false" />
                </providers>
            </sessionState>
        </system.web>
    </configuration>
