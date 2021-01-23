    public static void MergeSlides(string presentationFolder, string sourcePresentation, string destPresentation)
    {
        int id = 0;
        // Open the destination presentation.
        using (PresentationDocument myDestDeck = PresentationDocument.Open(presentationFolder + destPresentation, true))
        {
            PresentationPart destPresPart = myDestDeck.PresentationPart;
            // If the merged presentation does not have a SlideIdList element yet, add it.
            if (destPresPart.Presentation.SlideIdList == null)
                destPresPart.Presentation.SlideIdList = new SlideIdList();
            // Open the source presentation. This will throw an exception if the source presentation does not exist.
            using (PresentationDocument mySourceDeck = PresentationDocument.Open(presentationFolder + sourcePresentation, false))
            {
                PresentationPart sourcePresPart = mySourceDeck.PresentationPart;
                // Get unique ids for the slide master and slide lists for use later.
                uniqueId = GetMaxSlideMasterId(destPresPart.Presentation.SlideMasterIdList);
                uint maxSlideId = GetMaxSlideId(destPresPart.Presentation.SlideIdList);
                // Copy each slide in the source presentation, in order, to the destination presentation.
                foreach (SlideId slideId in sourcePresPart.Presentation.SlideIdList)
                {
                    SlidePart sp;
                    SlidePart destSp;
                    SlideMasterPart destMasterPart;
                    string relId;
                    SlideMasterId newSlideMasterId;
                    SlideId newSlideId;
                    // Create a unique relationship id.
                    id++;
                    sp = (SlidePart)sourcePresPart.GetPartById(slideId.RelationshipId);
                    relId = sourcePresentation.Remove(sourcePresentation.IndexOf('.')) + id;
                    // Add the slide part to the destination presentation.
                    destSp = destPresPart.AddPart<SlidePart>(sp, relId);
                    // The slide master part was added. Make sure the relationship between the main presentation part and
                    // the slide master part is in place.
                    destMasterPart = destSp.SlideLayoutPart.SlideMasterPart;
                    destPresPart.AddPart(destMasterPart);
                    // Add the slide master id to the slide master id list.
                    uniqueId++;
                    newSlideMasterId = new SlideMasterId();
                    newSlideMasterId.RelationshipId = destPresPart.GetIdOfPart(destMasterPart);
                    newSlideMasterId.Id = uniqueId;
                    destPresPart.Presentation.SlideMasterIdList.Append(newSlideMasterId);
                    // Add the slide id to the slide id list.
                    maxSlideId++;
                    newSlideId = new SlideId();
                    newSlideId.RelationshipId = relId;
                    newSlideId.Id = maxSlideId;
                    destPresPart.Presentation.SlideIdList.Append(newSlideId);
                }
                // Make sure that all slide layout ids are unique.
                FixSlideLayoutIds(destPresPart);
            }
            // Save the changes to the destination deck.
            destPresPart.Presentation.Save();
        }
    }
       public static void FixSlideLayoutIds(PresentationPart presPart)
        {
            //Need to make sure all slide layouts have unique ids
            foreach (SlideMasterPart slideMasterPart in presPart.SlideMasterParts)
            {
                foreach (SlideLayoutId slideLayoutId in slideMasterPart.SlideMaster.SlideLayoutIdList)
                {
                    uniqueId++;
                    slideLayoutId.Id = (uint)uniqueId;
                }
                slideMasterPart.SlideMaster.Save();
            }
        }
