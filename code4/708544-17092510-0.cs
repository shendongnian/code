    private void lettterGrammar() {
        GrammarBuilder letterGb = new GrammarBuilder();
        Choices letterChoices = new Choices("A", "B", "C", "D);
        GrammarBuilder speellingGb = new GrammarBuilder(
                     (GrammarBuilder)letterChoices, 1, 50);
        Grammar grammar = new Grammar(spellingGb);
    }
