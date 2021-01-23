    Dictionary<type, string> typeControllerMap =
        edmModel.SchemaElements.OfType<IEdmEntityContainer>()
                .Single()
                .Elements.OfType<IEdmEntitySet>()
                .Select(es => new { t = FindType(es.ElementType.FullName()), n = es.Name })
                .Where(tn => tn.t != null)
                .ToDictionary(tn => tn.t, tn => tn.n);
