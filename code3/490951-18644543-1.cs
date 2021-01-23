    // from above code snippet
    catch (HttpRequestValidationException)
    {
        // handle any potentially dangerous form values here.  Don't want an exception bubbling up to the user
        // so handle the HttpRequestValidationException by hand here
        // manually populate the model here so that the original values are presented back to the user
        model = new Foo()
        {
            Bar = HandleHttpRequestValidationExceptionHelper.TryAssignment(bindingContext.ModelState, () => bindingContext.ValueProvider.GetValue("Bar").AttemptedValue),
            Baz = HandleHttpRequestValidationExceptionHelper.TryAssignment(bindingContext.ModelState, () => bindingContext.ValueProvider.GetValue("Baz").AttemptedValue)
        };
    }
    return model;
