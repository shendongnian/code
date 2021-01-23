	//Create
	var none = FSharpOption<string>.None;
	var some1 = FSharpOption<string>.Some("some1");
	var some2 = new FSharpOption<string>("some2");
	//Does it have value?
	var isNone1 = FSharpOption<string>.get_IsNone(none);
	var isNone2 = OptionModule.IsNone(none);
	var isNone3 = FSharpOption<string>.GetTag(none) == FSharpOption<string>.Tags.None;
	var isSome1 = FSharpOption<string>.get_IsSome(some1);
	var isSome2 = OptionModule.IsSome(some1);
	var isSome3 = FSharpOption<string>.GetTag(some2) == FSharpOption<string>.Tags.Some;
	//Access value
	var value1 = some1.Value; //NullReferenceException when None
	var value2 = OptionModule.GetValue(some1); //ArgumentException when None
