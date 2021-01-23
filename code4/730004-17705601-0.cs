    if (!ModelState.IsValid && vm.SectionMarkedForDeletion)
        ModelState.ToList().ForEach(x =>
            {
                if (x.Key.Contains("Section"))
                    x.Value.Errors.Clear();
            });
