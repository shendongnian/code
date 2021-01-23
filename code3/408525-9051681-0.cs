    public static void SetTypeToListCollectionView(Type t, CollectionViewSource collectionViewSource)
        {
            ListCollectionView repositoryView = (ListCollectionView)collectionViewSource.View;
            if (!repositoryView.CanAddNew)
            {
                ConstructorInfo ci = t.GetConstructor(new Type[] { });
                FieldInfo field = repositoryView.GetType().GetField("_itemConstructor", BindingFlags.Instance | BindingFlags.NonPublic);
                field.SetValue(repositoryView, ci);
            }
        }
