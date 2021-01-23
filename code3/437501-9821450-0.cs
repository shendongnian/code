    public static List<MediumRole> MediumGetParticipants(int mediumId, int itemsPrPage, int page)
        {
            Medium medium = MediaHelper.GetMedium(mediumId);
            // Check if media not is null
            if (medium == null) return null;
            using (var context = new DbContext())
            {
              context.Attach(medium);
              return medium.MediumRoles.Page(page, itemsPrPage).ToList();
            }
        }
