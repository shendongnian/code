    [Cmdlet(Verb = VerbsCommon.Get, Noun = "Answer")]
    public class GetAnswerCommand : PSCmdlet {
        public override void EndProcessing() {
            WriteObject(42);
        }
    }
