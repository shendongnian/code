    <WizardSchema>
      <Steps>
        <Step>
          <StepID>1</StepID>
          <StepOrder>1</StepOrder>
          <StepTitle>First Step</StepTitle>
          <StepUrl>~/step1.aspx</StepUrl>
          <Tasks>
            <Task>
              <TaskID>1</TaskID>
              <TaskOrder>1</TaskOrder>
              <TaskPrompt>Enter your first name:</TaskPrompt>
              <TaskControlID>FirstNameTextBox</TaskControlID>
              <VisibilityDependencyList></VisibilityDependencyList>
              <IsCompleted>True</IsCompleted>
            </Task>
            <Task>
              <TaskID>2</TaskID>
              <TaskOrder>2</TaskOrder>
              <TaskPrompt>Enter your last name:</TaskPrompt>
              <TaskControlID>LastNameTextBox</TaskControlID>
              <VisibilityDependencyList>
                <VisibilityDependency StepID="1" TaskID="1" />
              </VisibilityDependencyList>
              <IsCompleted>False</IsCompleted>
            </Task>
          </Tasks>
        </Step>
        <Step>
          <StepID>2</StepID>
          <StepOrder>2</StepOrder>
          <StepTitle>Second Step</StepTitle>
          <StepUrl>~/step2.aspx</StepUrl>
          <Tasks>
            <Task>
              <TaskID>3</TaskID>
              <TaskOrder>1</TaskOrder>
              <TaskPrompt>Enter your phone number type:</TaskPrompt>
              <TaskControlID>PhoneNumberTypeDropDown</TaskControlID>
              <VisibilityDependencyList>
                <VisibilityDependency StepID="1" /> 
                <!-- Not setting a TaskID attribute here means ALL tasks should be complete in Step 1 for this dependency to return true -->
              </VisibilityDependencyList>
              <IsCompleted>False</IsCompleted>
            </Task>
            <Task>
              <TaskID>4</TaskID>
              <TaskOrder>2</TaskOrder>
              <TaskPrompt>Enter your phone number:</TaskPrompt>
              <TaskControlID>PhoneNumberTextBox</TaskControlID>
              <VisibilityDependencyList>
                <VisibilityDependency StepID="1" />
                <VisibilityDependency StepID="2" TaskID="1" />
              </VisibilityDependencyList>
              <IsCompleted>False</IsCompleted>
            </Task>
          </Tasks>
        </Step>
      </Steps>
    </WizardSchema>
