    public abstract class Instruction
    {
        protected Instruction(InstructionSet instructionSet, ExpressionElement argument, RealInstructionGetter realInstructionGetter)
        {
            if (realInstructionGetter != null)
            {
                RealInstruction = realInstructionGetter.GetRealInstruction(instructionSet, argument);
            }
        }
        public Instruction RealInstruction { get; set; }
        // Abstracted what used to be the virtual method, into it's own class that itself can be inherited from.
        // When doing this I often make them inner/nested classes as they're not usually relevant to any other classes.
        // There's nothing stopping you from making this a standalone class of it's own though.
        protected abstract class RealInstructionGetter
        {
            public abstract Instruction GetRealInstruction(InstructionSet instructionSet, ExpressionElement argument);
        }
    }
    // A sample derived Instruction class
    public class FooInstruction : Instruction
    {
        // Passes a concrete instance of a RealInstructorGetter class
        public FooInstruction(InstructionSet instructionSet, ExpressionElement argument) 
            : base(instructionSet, argument, new FooInstructionGetter())
        {
        }
        // Inherits from the nested base class we created above.
        private class FooInstructionGetter : RealInstructionGetter
        {
            public override Instruction GetRealInstruction(InstructionSet instructionSet, ExpressionElement argument)
            {
                // Returns a specific real instruction
                return new FooRealInstuction(instructionSet, argument);
            }
        }
    }
    // Another sample derived Instruction classs showing how you effictively "override" the RealInstruction that is passed to the base class.
    public class BarInstruction : Instruction
    {
        public BarInstruction(InstructionSet instructionSet, ExpressionElement argument)
            : base(instructionSet, argument, new BarInstructionGetter())
        {
        }
        private class BarInstructionGetter : RealInstructionGetter
        {
            public override Instruction GetRealInstruction(InstructionSet instructionSet, ExpressionElement argument)
            {
                // We return a different real instruction this time.
                return new BarRealInstuction(instructionSet, argument);
            }
        }
    }
