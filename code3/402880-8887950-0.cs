        public IEnumerable<Pet> speciesChecker()
        {
            var species = new Dictionary<Species, List<Pet>>();
            foreach (Pet pet in _pets)
            {
                // create the list if it doesn't exist
                if (!species.ContainsKey(pet.Species))
                    species[pet.Species] = new List<Pet>();
                species[pet.Species].Add(pet);
            }
            // foreach species, if there is only one pet of that species, then return it
            foreach (var speciesPets in species.Values)
            {
                if (speciesPets.Count() == 1)
                    yield return speciesPets.First();
            }
            yield break;
        }
