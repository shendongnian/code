    // construct the view.
    var factory = Situation.GetCurrentSituationFactory(); //abstract factory.
    var uiBuilder = factory.GetUIBuilder(); //abstract builder
    var structure = uiBuilder.GetFormStructure([context goes here]); //build view definition
    var viewParser = Platform.GetViewParser(); //abstract builder (step 2)
    viewParser.ConstructForm([context with form goes here]); //build form UI
    
    // later on, process the input data.
    var input = viewPrser.GetInput([context with form goes here]); //input definition
    var dataProcessor = factory.GetDataPocessor(); //strategy
    dataProcessor.Process(input); //execute processing strategy
