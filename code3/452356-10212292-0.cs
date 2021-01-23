    //---------------------------------------------------------------------- 
    // <copyright file="ObjectItemAttributeAssemblyLoader.cs" company="Microsoft">
    //      Copyright (c) Microsoft Corporation.  All rights reserved.
    // </copyright>
    // 
    // @owner       [....]
    // @backupOwner [....] 
    //--------------------------------------------------------------------- 
 
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Objects.DataClasses;
    using System.Diagnostics; 
    using System.Reflection;
    namespace System.Data.Metadata.Edm 
    {
      /// <summary> 
      /// Class for representing a collection of items for the object layer.
      /// Most of the implemetation for actual maintainance of the collection is
      /// done by ItemCollection
      /// </summary> 
      internal sealed class ObjectItemAttributeAssemblyLoader :
          ObjectItemAssemblyLoader
      { 
        // ...
        /// <summary>
        /// This method loads all the relationship type that this entity takes part in
        /// </summary> 
        /// <param name="entityType"></param>
        /// <param name="context"></param> 
        private void LoadRelationshipTypes() 
        {
          foreach (EdmRelationshipAttribute roleAttribute in
                   SourceAssembly.GetCustomAttributes(typeof(EdmRelationshipAttribute), false /*inherit*/)) 
          {
            // Check if there is an entry already with this name
            if (TryFindNullParametersInRelationshipAttribute(roleAttribute))
            { 
              // don't give more errors for these same bad parameters
              continue; 
            } 
            bool errorEncountered = false; 
            // return error if the role names are the same
            if (roleAttribute.Role1Name == roleAttribute.Role2Name)
            { 
              SessionData.EdmItemErrors.Add(new EdmItemError(
                  System.Data.Entity.Strings.SameRoleNameOnRelationshipAttribute(roleAttribute.RelationshipName, roleAttribute.Role2Name),
                           null)); 
              errorEncountered = true; 
            }
 
            if (!errorEncountered)
            {
              AssociationType associationType = new AssociationType(
                roleAttribute.RelationshipName, roleAttribute.RelationshipNamespaceName,
                roleAttribute.IsForeignKey, DataSpace.OSpace); 
              SessionData.TypesInLoading.Add(associationType.FullName, associationType);
              TrackClosure(roleAttribute.Role1Type); 
              TrackClosure(roleAttribute.Role2Type); 
              // prevent lifting of loop vars 
              string r1Name = roleAttribute.Role1Name;
              Type r1Type = roleAttribute.Role1Type;
              RelationshipMultiplicity r1Multiplicity = roleAttribute.Role1Multiplicity;
              AddTypeResolver(() => 
                ResolveAssociationEnd(associationType, r1Name, r1Type, r1Multiplicity));
 
              // prevent lifting of loop vars 
              string r2Name = roleAttribute.Role2Name;
              Type r2Type = roleAttribute.Role2Type; 
              RelationshipMultiplicity r2Multiplicity = roleAttribute.Role2Multiplicity;
              AddTypeResolver(() =>
                ResolveAssociationEnd(associationType, r2Name, r2Type, r2Multiplicity));
 
              // get assembly entry and add association type to the list of types in the assembly
              Debug.Assert(!CacheEntry.ContainsType(associationType.FullName), "Relationship type must not be present in the list of types"); 
              CacheEntry.TypesInAssembly.Add(associationType); 
            }
          } 
        }
        // ...
      }
    }
