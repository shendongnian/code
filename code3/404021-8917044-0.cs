    protected InstructionInfo(...)
    {
        // ...
        SetupInstruction();
    }
    private void SetupInstruction()
    {
        // Common setup
        // ...
        // Custom setup
        SetupInstructionCore();
    }
    // Either an optionally overriddable method
    protected virtual void SetupInstructionCore()
    {
    }
    // Or a required override
    protected abstract void SetupInstructionCore();
