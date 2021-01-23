    using Microsoft.WindowsAPICodePack.Dialogs;
    internal class TaskDialogCommandLinkEx : TaskDialogCommandLink
    {
        public override string ToString()
        {
            string str;
            var noLabel = string.IsNullOrEmpty(Text);
            var noInstruction = string.IsNullOrEmpty(Instruction);
            if (noLabel & noInstruction)
            {
                str = string.Empty;
            }
            else if (!noLabel & noInstruction)
            {
                str = Text;
            }
            else if (noLabel & !noInstruction)
            {
                str = Instruction;
            }
            else
            {
                str = Text + "\n" + Instruction;
            }
            return str;
        }
    }
