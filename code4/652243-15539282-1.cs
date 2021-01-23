         <?xml version="1.0" encoding="UTF-16"?> <Task version="1.2"
          xmlns="http://schemas.microsoft.com/windows/2004/02/mit/task">  
         <RegistrationInfo>
              <Date>2012-10-29T17:57:58.8640417</Date>
              <Author>SERVER\AdminAccount</Author>
             <Description>Wakes up Reporting services when the service shuts down</Description>   </RegistrationInfo>   <Triggers>
              <CalendarTrigger>
               <Repetition>
                  <Interval>PT1H</Interval>
                  <StopAtDurationEnd>false</StopAtDurationEnd>
                </Repetition>
                <StartBoundary>2012-11-01T21:06:52.4488088</StartBoundary>
                <Enabled>true</Enabled>
                <ScheduleByDay>
                  <DaysInterval>1</DaysInterval>
                </ScheduleByDay>
            </CalendarTrigger>   </Triggers>   <Principals>
              <Principal id="Author">
                <UserId>SERVER\AdminUser</UserId>
                <LogonType>Password</LogonType>
                <RunLevel>LeastPrivilege</RunLevel>
              </Principal>   </Principals>   <Settings>
              <MultipleInstancesPolicy>IgnoreNew</MultipleInstancesPolicy>
              <DisallowStartIfOnBatteries>false</DisallowStartIfOnBatteries>
              <StopIfGoingOnBatteries>false</StopIfGoingOnBatteries>
              <AllowHardTerminate>true</AllowHardTerminate>
              <StartWhenAvailable>true</StartWhenAvailable>
              <RunOnlyIfNetworkAvailable>false</RunOnlyIfNetworkAvailable>
              <IdleSettings>
                <StopOnIdleEnd>true</StopOnIdleEnd>
                <RestartOnIdle>false</RestartOnIdle>
              </IdleSettings>
             <AllowStartOnDemand>true</AllowStartOnDemand>
              <Enabled>true</Enabled>
              <Hidden>false</Hidden>
              <RunOnlyIfIdle>false</RunOnlyIfIdle>
              <WakeToRun>false</WakeToRun>
              <ExecutionTimeLimit>P3D</ExecutionTimeLimit>
              <Priority>7</Priority>   </Settings>   <Actions Context="Author">
              <Exec>
                <Command>C:\<ScriptFolder\wakeup.cmd</Command>
              </Exec>   </Actions> </Task>
